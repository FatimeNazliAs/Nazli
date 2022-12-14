using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nazli.Business.Concrete;
using Nazli.DataLayer;
using Nazli.DataLayer.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ChatAppContext>();
builder.Services.AddScoped<DalUser>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddScoped<DalMessage>();
builder.Services.AddScoped<MessageManager>();

builder.Services.AddScoped<DalGroup>();
builder.Services.AddScoped<GroupManager>();

builder.Services.AddScoped<DalGroupMember>();
builder.Services.AddScoped<GroupMemberManager>();

builder.Services.AddScoped<DalFriend>();
builder.Services.AddScoped<FriendManager>();

builder.Services.AddScoped<DalComplain>();
builder.Services.AddScoped<ComplainManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//builder.Services.AddDbContext<ChatAppContext>(opt =>
//{
//    opt.UseMySql("YOUR_CONNECTION_STRING");
//});


app.UseAuthorization();

app.MapControllers();

app.Run();
