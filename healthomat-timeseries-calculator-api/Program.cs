using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TimeSeriesCalculator.Application;
using TimeSeriesCalculator.Application.Exceptions;
using TimeSeriesCalculator.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TimeSeriesCalculatorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDbContext"));

});

builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Healthomat TimeSeriesCalculator Service", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             }
                        },
                         new string[] {}

                    }
                });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Audience = AmazonEntryPoint.ClientId();
        options.Authority = $"https://cognito-idp.us-east-1.amazonaws.com/{AmazonEntryPoint.UserPoolId()}";
    });

Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", "AKIAXR75C5K2X6HN5E5E");
Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", "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");
Environment.SetEnvironmentVariable("AWS_REGION", "us-east-1");

var awsOptions = builder.Configuration.GetAWSOptions();
awsOptions.Credentials = new Amazon.Runtime.EnvironmentVariablesAWSCredentials();
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonS3>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
