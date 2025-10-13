using TodoListMinimalApi.Data;
using TodoListMinimalApi.Dto;
using TodoListMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Host={host};Port={port};Database={dbName};Username={user};Password={password}";


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoListDb>(options=>options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/listitems", async(TodoListDb context) =>
{
    var res = await context.ListItems.ToListAsync();
    return Results.Ok(res);
});

app.MapGet("listitems/{id}",async(TodoListDb context, int id)=>{
    var res = await context.ListItems.FindAsync(id);
    return Results.Ok(res);    
});

app.MapPut("listitems/{id}",async(TodoListDb context, int id, ListItemDto item)=>{
    ListItem res = await context.ListItems.FindAsync(id);
    if(res==null) return Results.NotFound();
    res.Title=item.Title;
    res.Content=item.Content;
    res.Date=item.Date;
    res.Author=item.Author;
    await context.SaveChangesAsync();
    return Results.NoContent();   
});

app.MapPost("listitems/newitem",async(TodoListDb context, ListItemDto item)=>{
    if(item==null) return Results.NotFound();
    context.Add(item);
    await context.SaveChangesAsync();
    return Results.Created("listitems/{item.Id}",item);    
});

app.MapDelete("listitems/{id}",async(TodoListDb context, int id)=>{
    var res = await context.ListItems.FindAsync(id);
    if(res==null) return Results.NotFound();
    context.ListItems.Remove(res);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

