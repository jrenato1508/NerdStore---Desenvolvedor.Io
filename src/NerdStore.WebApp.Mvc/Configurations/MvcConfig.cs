namespace NerdStore.WebApp.Mvc.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            #region AddDatabaseDeveloperPageExceptionFilter
            /*
              Adiciona uma pagina que é um execptionFilter para erros de Database ao projeto. esse serviço irá filtar os erros que são de databse(banco de dados) e vai tratar eles
              em uma pagina expecifica.

              Porque Usar?
              Imagina que estamos estamos cloando um projeto que está em um repositorio do nosso gitHub. Esse projeto já foi finalizado e queremos testar na nosso novo ambiente.
              Porém nós não temos os bancos instalados ainda e ao executar e interagir com o projeto recebemos um erro no navegador com uma mensagem generica que dificulda o
              nosso entendimento para resolver e no final percebemos que o problema era o banco de dados que não tinhamos. Adicionando esse serviço o projeto conta com um filtro
              que irá exibir em uma pagina somente os erros de banco de dados e que inclusive nos auxilia como resolver.

              Caso o Projeto clonado já possua as migrations nele. Ao executar o projeto e interagir com ele, o erro no navegador vai ser diferente. O projeto vai identiricar que nós
              já possuimos as migrations e irá exibir no navegador a opção de aplicar as migrations.
             */
            #endregion
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddRazorPages();


            return services;
        }
    }
}
