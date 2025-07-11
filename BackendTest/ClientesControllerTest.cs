﻿using Backend.Controllers;
using Backend.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Tests
{
    public class ClientesControllerTest
    {
        SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
        DbContextOptions<KioscoContext> options;

        public ClientesControllerTest()
        {
            connection.Open();
            options = new DbContextOptionsBuilder<KioscoContext>()
                .UseSqlite(connection)
                .Options;
        }

        [Fact]
        public async void GetClientes()
        {
            //*** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {
                context.Database.EnsureCreated();

                var clientesController = new ClientesController(context);

                //****ACT
                var result = await clientesController.GetClientes();
                //convierto el result en una lista
                var lista = result.Value.ToList();

                //***ASSERT
                //verifico que la lista no sea nula
                Assert.NotNull(lista);
                //verifico que la lista no este vacia
                Assert.NotEmpty(lista);
                //verifico que la lista tenga al menos un elemento
                Assert.True(lista.Count > 0);
                //verifico que la lista sea igual a 4
                Assert.Equal(5, lista.Count);
            }
            // Cerrar la conexión al finalizar
            connection.Close();

        }

        [Theory]
        [InlineData(1, "Juan Pérez")]
        [InlineData(2, "María López")]
        public async void GetCliente_JuanPerez_y_MariaLopez(int idGet, string valueExpect)

        {
            //*** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {
                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                //***ACT
                var result = await clientesController.GetCliente(idGet);

                //***ASSERT
                //verifico que el resultado no sea nulo
                Assert.NotNull(result);
                //verifico que el resultado sea de tipo OkObjectResult
                //verifico que el resultado no sea de tipo NotFoundResult
                Assert.IsNotType<NotFoundResult>(result.Result);
                //verifico que el resultado no sea de tipo BadRequestResult
                Assert.IsNotType<BadRequestResult>(result.Result);
                //verifico que el resultado no sea de tipo NoContentResult
                Assert.IsNotType<NoContentResult>(result.Result);
                //verifico que el resultado no sea de tipo StatusCodeResult
                Assert.IsNotType<StatusCodeResult>(result.Result);
                //verifico que el resultado no sea de tipo UnauthorizedResult
                Assert.IsNotType<UnauthorizedResult>(result.Result);
                //verifico que el resultado no sea de tipo ForbidResult
                Assert.IsNotType<ForbidResult>(result.Result);
                //verifico que el resultado no sea de tipo ConflictResult
                Assert.IsNotType<ConflictResult>(result.Result);
                //verifico que el resultado no sea de tipo CreatedResult
                Assert.IsNotType<CreatedResult>(result.Result);
                //verifico que el resultado no sea de tipo AcceptedResult
                Assert.IsNotType<AcceptedResult>(result.Result);
                //verifico que el resultado no sea de tipo NotFoundObjectResult
                Assert.IsNotType<NotFoundObjectResult>(result.Result);
                //verifico que el resultado no sea de tipo BadRequestObjectResult
                Assert.IsNotType<BadRequestObjectResult>(result.Result);
                //verifico que el resultado no sea de tipo ObjectResult
                Assert.IsNotType<ObjectResult>(result.Result);
                //verifico que el resultado no sea de tipo UnauthorizedObjectResult
                Assert.IsNotType<UnauthorizedObjectResult>(result.Result);
                //verifico que el resultado no sea de tipo ConflictObjectResult
                Assert.IsNotType<ConflictObjectResult>(result.Result);
                //verifico que el resultado no sea de tipo OkResult
                Assert.IsNotType<OkResult>(result.Result);
                //transformo el resultado en un objeto Localidad
                var cliente = result.Value as Cliente;
                //verifico que el objeto no sea nulo
                Assert.NotNull(cliente);
                //verifico que el objeto no sea vacio
                Assert.NotEmpty(cliente.Nombre);
                //verifico que sea igual a "San Justo"
                Assert.Equal(valueExpect, cliente.Nombre);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }

        //[Fact(Skip ="Este test ya lo estamos probando en el test hecho con Theory")]
        //public async void GetCliente_JuanPerez()
        //{
        //    //*** Arrange
        //    // Crear la base de datos y aplicar las migraciones
        //    using (var context = new KioscoContext(options))
        //    {
        //        context.Database.EnsureCreated();
        //        var clientesController = new ClientesController(context);
        //        //***ACT
        //        var result = await clientesController.GetCliente(1);

        //        //***ASSERT
        //        //verifico que el resultado no sea nulo
        //        Assert.NotNull(result);
        //        //verifico que el resultado sea de tipo OkObjectResult
        //        //verifico que el resultado no sea de tipo NotFoundResult
        //        Assert.IsNotType<NotFoundResult>(result.Result);
        //        //verifico que el resultado no sea de tipo BadRequestResult
        //        Assert.IsNotType<BadRequestResult>(result.Result);
        //        //verifico que el resultado no sea de tipo NoContentResult
        //        Assert.IsNotType<NoContentResult>(result.Result);
        //        //verifico que el resultado no sea de tipo StatusCodeResult
        //        Assert.IsNotType<StatusCodeResult>(result.Result);
        //        //verifico que el resultado no sea de tipo UnauthorizedResult
        //        Assert.IsNotType<UnauthorizedResult>(result.Result);
        //        //verifico que el resultado no sea de tipo ForbidResult
        //        Assert.IsNotType<ForbidResult>(result.Result);
        //        //verifico que el resultado no sea de tipo ConflictResult
        //        Assert.IsNotType<ConflictResult>(result.Result);
        //        //verifico que el resultado no sea de tipo CreatedResult
        //        Assert.IsNotType<CreatedResult>(result.Result);
        //        //verifico que el resultado no sea de tipo AcceptedResult
        //        Assert.IsNotType<AcceptedResult>(result.Result);
        //        //verifico que el resultado no sea de tipo NotFoundObjectResult
        //        Assert.IsNotType<NotFoundObjectResult>(result.Result);
        //        //verifico que el resultado no sea de tipo BadRequestObjectResult
        //        Assert.IsNotType<BadRequestObjectResult>(result.Result);
        //        //verifico que el resultado no sea de tipo ObjectResult
        //        Assert.IsNotType<ObjectResult>(result.Result);
        //        //verifico que el resultado no sea de tipo UnauthorizedObjectResult
        //        Assert.IsNotType<UnauthorizedObjectResult>(result.Result);
        //        //verifico que el resultado no sea de tipo ConflictObjectResult
        //        Assert.IsNotType<ConflictObjectResult>(result.Result);
        //        //verifico que el resultado no sea de tipo OkResult
        //        Assert.IsNotType<OkResult>(result.Result);
        //        //transformo el resultado en un objeto Localidad
        //        var cliente = result.Value as Cliente;
        //        //verifico que el objeto no sea nulo
        //        Assert.NotNull(cliente);
        //        //verifico que el objeto no sea vacio
        //        Assert.NotEmpty(cliente.Nombre);
        //        //verifico que sea igual a "San Justo"
        //        Assert.Equal("Juan Pérez", cliente.Nombre);
        //    }
        //    // Cerrar la conexión al finalizar
        //    connection.Close();
        //}
        [Fact]
        public async void GetCliente_NoFound()
        {
            //*** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {
                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                //***ACT
                var result = await clientesController.GetCliente(1000);
                //***ASSERT
                //verifico que el resultado no sea nulo
                Assert.NotNull(result);
                //verifico que el resultado sea de tipo NotFoundResult
                Assert.IsType<NotFoundResult>(result.Result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }
        [Fact]
        public async void PutCliente_Exception_ArgumentNull()
        {
            //*** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {
                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nombre = "Juan Perez",
                    Direccion = "Av. Rivadavia 1234",
                    Telefonos = "011-12345678",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    LocalidadId = 1,
                    Eliminado = false
                };
                //***ACT
                //verifico que el resultado sea de tipo BadRequest
                var result = await clientesController.PutCliente(null, cliente);
                Assert.IsType<BadRequestResult>(result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }
        [Fact]
        public async void PutCliente_ArgumentNullException()
        {
            //*** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {
                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                //***ACT
                //verifico que el resultado sea de tipo ArgumentNullException
                await Assert.ThrowsAsync<ArgumentNullException>(async () => await
                clientesController.PutCliente(1, null));
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }

        [Fact]
        public async void PutCliente_BadRequest_ArgumentNull()
        {
            //** Arrange
            // Crear la base de datos y aplicar las migraciones
            using (var context = new KioscoContext(options))
            {

                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nombre = "Juan Perez",
                    Direccion = "Av. Rivadavia 1234",
                    Telefonos = "011-12345678",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    LocalidadId = 1,
                    Eliminado = false
                };
                //** ACT
                // Verifico que el resultado sea de tipo BadRequest
                var result = await clientesController.PutCliente(null, cliente);
                Assert.IsType<BadRequestResult>(result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }
        [Fact]

        public async void DeleteCliente_NotFound_Mock()

        {
            //*** arrange

            var context = new Mock<KioscoContext>(options);
            context.Setup(c => c.Clientes.FindAsync(It.IsAny<int?>())).ReturnsAsync((Cliente)null);
            var clientesController = new ClientesController(context.Object);

            //*ACT

            var result = await clientesController.DeleteCliente(1000);

            //*ASSERT

            //verifico que el resultado sea Not Found

            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]

        public async void DeleteCliente_Id_1()
        {
            //*** arrange

            // Crear la base de datos y aplicar las migraciones using (var context = new KioscoContext(options))
            using (var context = new KioscoContext(options))

            {
                context.Database.EnsureCreated();
                var clientesController = new ClientesController(context);

                //*ACT

                var result = await clientesController.DeleteCliente(1);

                //*ASSERT

                //verifico que el resultado no sea nulo

                Assert.NotNull(result);

                //verifico que el resultado sea de tipo OkObjectResult

                Assert.IsType<NoContentResult>(result);
            }

            // Cerrar la conexión al finalizar

            connection.Close();
        }
        [Fact]

        public async void PostCliente()

        {
            using (var context = new KioscoContext(options)) ;

            {
                ContextBoundObject.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nombre = "Juan Fernandez",
                    Direccion = "Av. Rivadavia 1234",
                    Telefonos = "011-12345678",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    LocalidadId = 1,
                    Eliminado = false
                };
                //***ACT
                var result = await clientesController.PostCliente(cliente);
                //***ASSERT
                //verifico que el resultado no sea nulo
                Assert.NotNull(result);
                //verifico que el resultado sea de tipo CreatedAtActionResult
                Assert.IsType<CreatedAtActionResult>(result.Result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }

        [Fact]

        public async void PutCliente()

        {
            using (var context = new KioscoContext(options)) ;

            {
                ContextBoundObject.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nombre = "Monica Mellano",
                    Direccion = "Av. Rivadavia 1234",
                    Telefonos = "011-12345678",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    LocalidadId = 1,
                    Eliminado = false
                };
                //***ACT
                var result = await clientesController.PutCliente(1, cliente);
                //***ASSERT
                //verifico que el resultado no sea nulo
                Assert.NotNull(result);
                //verifico que el resultado sea de tipo CreatedAtActionResult
                Assert.IsType<CreatedAtActionResult>(result.Result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }
        [Fact]

        public async void PutCliente_BadRequest()
        {
            using (var context = new KioscoContext(options)) ;
            {
                ContextBoundObject.Database.EnsureCreated();
                var clientesController = new ClientesController(context);
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nombre = "Juan Perez",
                    Direccion = "Av. Rivadavia 1234",
                    Telefonos = "011-12345678",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    LocalidadId = 1,
                    Eliminado = false
                };
                //***ACT
                var result = await clientesController.PutCliente(1000, cliente);
                //***ASSERT
                //verifico que el resultado no sea nulo
                Assert.NotNull(result);
                //verifico que el resultado sea de tipo BadRequestResult
                Assert.IsType<BadRequestResult>(result);
            }
            // Cerrar la conexión al finalizar
            connection.Close();
        }

        [Fact] 

        public async void PutCliente_DbUpdateConcurrencyException()
        {
            using (var context = new KioscoContext(options)) ;
            {
                //*** Arrange

                Assert.NotNull(result);

            } // Cerrar la conexión al finalizar

            var context = new Mock<KioscoContext>(options);

            //seteamos que cuando llamamos al SaveChangesAsync() devuelva un pbUpdateConcurrencyException
            context.Setup(c => c. SaveChangesAsync(It. IsAny<CancellationToken>())).ThrowsAsync(new DbUpdateConcurrencyException());

            //Seteamos que .Any devueva true con cualquier tipo de parametros 
            context.Setup(c => c.Clientes.Any(It.IsAny<Expression<Func<Cliente, bool>>>()))
            .Returns(false);
            var clientesController = new ClientesController(context.Object);

            var cliente = new Cliente()
            {
                Id = 1,
                Nombre = "Juan Perez",
                Direccion = "Av. Rivadavia 1234",
                Telefonos = "011-12345678",
                FechaNacimiento = new DateTime(1990, 1, 1),
                LocalidadId = 1,
                Eliminado = false
            };

            //verifico que el resultado sea de tipo DbUpdateConcurrencyException

            //***ACT
            var result = await clientesController.PutCliente(1, cliente);
            Assert.NotNull(result);
            Assert.IsType<DbUpdateConcurrencyException>(result);

            //*Verifico que el resultado no sea NotFount
            Assert.IsNotType<NotFoundResult>(result);


            connection.Close();
        }
    }
}
