using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTos.Requests
{
    public record CreateOrderRequestDto(string Productname,decimal Price);//вводит клиент  
}
