using SuporteTI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Session (corrigido e ampliado)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24); // mantém sessão por 24h
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // necessário para funcionar mesmo sem consentimento de cookies
});

// HttpClient + ApiService (caso use serviços internos para chamar a API)
builder.Services.AddHttpClient<ApiService>(client =>
{
    var baseUrl = builder.Configuration["Api:BaseUrl"]!.TrimEnd('/');
    client.BaseAddress = new Uri($"{baseUrl}/");
});

// Acesso ao contexto HTTP (para HttpContext.Session)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // segurança extra
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// Rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AuthWeb}/{action=Login}/{id?}");

app.Run();
