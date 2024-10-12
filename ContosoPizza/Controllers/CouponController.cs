using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers;

[ApiController, Route("[controller]")]
public class CouponController(PromotionsContext context) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Coupon> Get()
    {
        return context.Coupons.AsNoTracking().ToList();
    }
}