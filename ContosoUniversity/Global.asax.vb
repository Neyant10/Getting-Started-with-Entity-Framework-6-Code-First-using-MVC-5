Imports System.Web.Optimization
Imports ContosoUniversity.DAL
Imports System.Data.Entity.Infrastructure.Interception


Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        DbInterception.Add(New SchoolInterceptorTransientErrors)
        DbInterception.Add(New SchoolInterceptorLogging)
    End Sub
End Class
