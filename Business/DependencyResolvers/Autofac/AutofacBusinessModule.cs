using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ilManager>().As<IilService>().SingleInstance();
            builder.RegisterType<EfilDal>().As<IilDal>().SingleInstance();

            builder.RegisterType<ilceManager>().As<IilceService>().SingleInstance();
            builder.RegisterType<EfilceDal>().As<IilceDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<BransManager>().As<IBransService>().SingleInstance();
            builder.RegisterType<EfBransDal>().As<IBransDal>().SingleInstance();

            builder.RegisterType<KurumTuruManager>().As<IKurumTuruService>().SingleInstance();
            builder.RegisterType<EfKurumTuruDal>().As<IKurumTuruDal>().SingleInstance();

            builder.RegisterType<KurumTipiManager>().As<IKurumTipiService>().SingleInstance();
            builder.RegisterType<EfKurumTipiDal>().As<IKurumTipiDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserDetayManager>().As<IUserDetayService>().SingleInstance();
            builder.RegisterType<EfUserDetayDal>().As<IUserDetayDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();


            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
