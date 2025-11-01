using SuporteTI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// 1?? MVC
builder.Services.AddControllersWithViews();

// 2?? Session (corrigido e ampliado)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24); // mantém sessão por 24h
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // necessário para funcionar mesmo sem consentimento de cookies
});

// 3?? HttpClient + ApiService (caso use serviços internos para chamar a API)
builder.Services.AddHttpClient<ApiService>(client =>
{
    var baseUrl = builder.Configuration["Api:BaseUrl"]!.TrimEnd('/');
    client.BaseAddress = new Uri($"{baseUrl}/");
});

// 4?? Acesso ao contexto HTTP (para HttpContext.Session)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// 5?? Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // segurança extra
}

app.UseHttpsRedirection(); // garante HTTPS
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ?? precisa vir ANTES de UseAuthorization

// (caso venha a usar autenticação por cookies ou JWT no futuro)
app.UseAuthorization();

// 6?? Rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AuthWeb}/{action=Login}/{id?}"); // ?? inicia no login web

app.Run();
