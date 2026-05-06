using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleCats.Api.Controller
{
    [Route("api/battleitem")]
    [ApiController]
    public class BattleItemController : ControllerBase
    {
        private IBattleItem _battleItem;

        public BattleItemController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _battleItem = bl.GetBattleItemActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllBattleItems()
        {
            var items = _battleItem.GetAllBattleItemsAction();
            return Ok(items);
        }

        [HttpGet("id")]
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
        public IActionResult Create([FromBody] BattleItemDto item)
        {
            var status = _battleItem.ResponceBattleItemCreateAction(item);
            return Ok(status);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BattleItemDto item)
        {
            var status = _battleItem.ResponceBattleItemUpdateAction(item);
            return Ok(status);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var status = _battleItem.ResponceBattleItemDeleteAction(id);
            return Ok(status);
        }
    }
}