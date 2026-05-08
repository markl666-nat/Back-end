using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleCats.Api.Controller
{
    /// <summary>
    /// Контроллер боевых юнитов Cat Base Shop.
    /// 
    /// По умолчанию [Authorize] на классе — все методы требуют валидный токен.
    /// GetAll/GetById помечены [AllowAnonymous] — каталог виден всем.
    /// Create/Update — только Manager+ или Admin.
    /// Delete — только Admin (нельзя удалять без admin-прав).
    /// </summary>
    [Route("api/battleitem")]
    [ApiController]
    [Authorize]
    public class BattleItemController : ControllerBase
    {
        private readonly IBattleItem _battleItem;

        public BattleItemController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _battleItem = bl.GetBattleItemActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAllBattleItems()
        {
            var items = _battleItem.GetAllBattleItemsAction();
            return Ok(items);
        }

        [HttpGet("id")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var item = _battleItem.GetBattleItemByIdAction(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create([FromBody] BattleItemDto item)
        {
            var status = _battleItem.ResponceBattleItemCreateAction(item);
            return Ok(status);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Update([FromBody] BattleItemDto item)
        {
            var status = _battleItem.ResponceBattleItemUpdateAction(item);
            return Ok(status);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var status = _battleItem.ResponceBattleItemDeleteAction(id);
            return Ok(status);
        }
    }
}