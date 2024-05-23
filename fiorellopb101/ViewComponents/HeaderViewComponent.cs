using fiorellopb101.Servioces.Interfaces;
using fiorellopb101.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fiorellopb101.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _accessor;
        public HeaderViewComponent(ISettingService settingService, IHttpContextAccessor accessor)
        {
            _settingService = settingService;
            _accessor = accessor;
        }
        public async Task<IViewComponentResult> InokeAsync()
        {
            List<BasketVM> basketDatas = new();
            if (_accessor.HttpContext.Request.Cookies["Basket"] is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["Basket"]);
            }
          

            Dictionary<string, string> settings = await _settingService.GetAllAsync();

            HeaderVM response = new HeaderVM()
            {
                Settings = settings,
                BasketCount =basketDatas.Sum(m=>m.Count),
                BasketTotalPrice = basketDatas.Sum(m=>m.Count* m.Price)
            };
            return await Task.FromResult(View(response));
    }
    public class HeaderVM
    {
        public int BasketCount { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public Dictionary<string,string> Settings { get; set; }

    }
}
