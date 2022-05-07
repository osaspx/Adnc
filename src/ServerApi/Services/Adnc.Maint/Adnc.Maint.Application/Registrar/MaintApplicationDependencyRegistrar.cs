﻿using Adnc.Shared.Application.Registrar;
using Adnc.Shared.Rpc.Grpc.Services;
using System.Reflection;

namespace Adnc.Maint.Application.Registrar;

public sealed class MaintApplicationDependencyRegistrar : AbstractApplicationDependencyRegistrar
{
    public override Assembly ApplicationLayerAssembly => Assembly.GetExecutingAssembly();

    public override Assembly ContractsLayerAssembly => typeof(IDictAppService).Assembly;

    public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;

    public MaintApplicationDependencyRegistrar(IServiceCollection services) : base(services)
    {
    }

    public override void AddAdnc()
    {
        AddApplicaitonDefault();
        //rpc-rest
        var restPolicies = this.GenerateDefaultRefitPolicies();
        var authRestAddress = IsDevelopment ? "http://localhost:50010" : "adnc.usr.webapi";
        AddRestClient<IAuthRestClient>(authRestAddress, restPolicies);
        //rpc-grpc
        var gprcPolicies = this.GenerateDefaultGrpcPolicies();
        var authGrpcAddress = IsDevelopment ? "http://localhost:50011" : "adnc.usr.webapi";
        AddGrpcClient<UsrGrpc.UsrGrpcClient>(authGrpcAddress, gprcPolicies);
    }
}