using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Webapi.Core.Model;
using Webapi.Core.Model.Enity;
using Webapi.Core.Repository.Sugar;

public class DbContext<T> where T : class, new()
{
    public static string ConnectionString { get; set; }
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = BaseDBConfig.ConnectionString,
            DbType = DbType.SqlServer,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }
    //注意：不能写成静态的
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
    public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

    public SimpleClient<User> UserDb { get { return new SimpleClient<User>(Db); } }//用来处理User表的常用操作





    //自已扩展更多方法 
}


