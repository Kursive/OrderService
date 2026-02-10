using OrderService.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTos.Responses
{
    public record  OrderItemResponse(string Productname,decimal Price,DateTime Create);  //данные которые видит клиент 
}
