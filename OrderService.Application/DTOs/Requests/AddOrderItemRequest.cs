using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTos.Requests
{
    public record AddOrderItemRequest(string Productname, decimal Price);//входные данные от клиента 
}
