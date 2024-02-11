using GovLookup.Business;
using GovLookup.Business.Contract;
using GovLookup.DataAccess;
using GovLookup.DataAccess.Repository;
using AutoMapper;



var GovLookupPolicy = "GovLookupPolicy";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: GovLookupPolicy,
                      policy =>
                      {
                      policy.WithOrigins("https://govlookup.mobdemo.org")
                          .AllowAnyHeader()
                          .AllowAnyMethod();                                           
                      });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICabinetService, CabinetService>();
builder.Services.AddSingleton<IJudiciaryService, JudiciaryService>();
builder.Services.AddSingleton<ILegislatorService, LegislatorService>();
builder.Services.AddSingleton<IBillsService, BillsService>();
builder.Services.AddSingleton<GovLookupDBContext>();
builder.Services.AddSingleton<IGovLookupRepository, GovLookupRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddSwaggerGenNewtonsoftSupport();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(config =>
{
        config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
        {
            ["activated"] = false
        };
});




app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(GovLookupPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
