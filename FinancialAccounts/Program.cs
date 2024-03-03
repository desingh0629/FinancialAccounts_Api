using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauthu2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountsConnection")));

builder.Services.AddScoped<IAccountGroupInterface, AccountGroupService>();
builder.Services.AddScoped<IBankInterface, BankService>();
builder.Services.AddScoped<IBudgetInterface, BudgetService>();
builder.Services.AddScoped<IChatOfAccountInterface, ChatOfAccountService>();
builder.Services.AddScoped<ICostCenterInterface, CostCenterService>();
builder.Services.AddScoped<ICurrencyExchangeRateInterface, CurrencyExchangeRateService>();
builder.Services.AddScoped<ICurrencyInterface, CurrencyService>();
builder.Services.AddScoped<ICustomerInterface, CustomerService>();
builder.Services.AddScoped<IPaymentMethodInterface, PaymentMethodService>();
builder.Services.AddScoped<IProductInterface,ProductService>();
builder.Services.AddScoped<IProductDetailInterface, ProductDetailService>();
builder.Services.AddScoped<IRoleInterface, RoleService>();
builder.Services.AddScoped<ISupplierInterface, SupplierService>();
builder.Services.AddScoped<ITaxCodeInterface, TaxCodeService>();
builder.Services.AddScoped<ITransactionInterface, TransactionService>();
builder.Services.AddScoped<IUsersInterface, UserService>();
builder.Services.AddScoped<IVoucherInterface, VoucherService>();
builder.Services.AddScoped<IVoucherDetailsInterface, VoucherDetailService>();

//add authendication 
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy =>
    {
        policy.WithOrigins("http://localhost:7271", "https://localhost:7271")
        .AllowAnyMethod()
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType);
    });
}
app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
