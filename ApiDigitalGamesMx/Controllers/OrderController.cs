﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.Library.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiDigitalGamesMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //https://localhost:44369/api/code
        // GET: api/<UserController>
        [HttpGet]
        //[Route("products")]
        //[Authorize]
        public IEnumerable<ApiProducts.Library.Models.PedidoCab> GetOrders()
        {
            List<ApiProducts.Library.Models.PedidoCab> listOrders = new List<ApiProducts.Library.Models.PedidoCab>();
            var ConnectionStringLocal = _configuration.GetValue<string>("CadenaConexion");
            using (IOrder order = Factorizador.CrearConexionServicioOrder(ApiProducts.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listOrders = order.GetOrders();
            }
            return listOrders;
        }

        [HttpPost]
        //[Route("")]
        //[Authorize]
        public IActionResult GetCode([FromBody] ApiProducts.Library.Models.PedidoCab value)
        {
            var ConnectionStringLocal = _configuration.GetValue<string>("CadenaConexion");
            //var ConnectionStringAzure = _configuration.GetValue<string>("ConnectionStringAzure");
            using (ApiProducts.Library.Interfaces.IOrder order = ApiProducts.Library.Interfaces.Factorizador.CrearConexionServicioOrder(ApiProducts.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            {
                ApiProducts.Library.Models.PedidoCab objusr = order.GetOrder(value.Id);

                if (objusr.Id > 0)
                {
                    return Ok(new
                    {
                        Pedido = objusr
                    });
                }

                return NotFound();

            }
        }

        [HttpPost]
        [Route("insertorder")]
        public IActionResult InsertOrder([FromBody] ApiProducts.Library.Models.opePedidoCab value)
        {
            int id = 0;
            var ConnectionStringLocal = _configuration.GetValue<string>("CadenaConexion");
            using (IOrder Order = Factorizador.CrearConexionServicioOrder(ApiProducts.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            {
                id = Order.InsertOrder(value.IdCliente, value.Total, value.FormPago, value.Nota);

                if (id > 0)
                {
                    return Ok(new
                    {
                        Id = id,
                        Estatus = "success",
                        Code = 200,
                        Msg = "Pedido insertado correctamente!!"

                    });
                }
            }

            return NotFound();

        }

        //https://localhost:44369/api/code
        // GET: api/<UserController>
        [HttpPost]
        [Route("detail")]
        //[Authorize]
        public IEnumerable<ApiProducts.Library.Models.PedidoDet> GetOrderDetail([FromBody] ApiProducts.Library.Models.PedidoCabMin value)
        {
            List<ApiProducts.Library.Models.PedidoDet> listOrders = new List<ApiProducts.Library.Models.PedidoDet>();
            var ConnectionStringLocal = _configuration.GetValue<string>("CadenaConexion");
            using (IOrder order = Factorizador.CrearConexionServicioOrder(ApiProducts.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listOrders = order.GetOrderDetail(value.Id);
            }
            return listOrders;
        }


    }
}
