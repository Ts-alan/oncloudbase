using Moq;
using Ninject;
using Ninject.Web.Common;
using oncloud.Domain.Abstract;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace oncloud.Web.oddBase.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера       
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера        
            // используя его тип       
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера     
            //Mock<IStreetsRepository> mock = new Mock<IStreetsRepository>();
            //mock.Setup(m => m.Streets).Returns(new List<Street> { 
            //    new Street {Caption = "Football" }, 
            //    new Street {Caption = "Football" },
            //}.AsQueryable());
            //ninjectKernel.Bind<IStreetsRepository>().ToConstant(mock.Object);
            //ninjectKernel.Bind<IStreetsRepository>().To<EFStreetsRepository>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope().WithConstructorArgument("EFDBContext");
        }
    }
}