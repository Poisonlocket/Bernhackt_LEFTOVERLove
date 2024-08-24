# Left Over Love Backend

## Database

### Create Migration

``` shell
dotnet ef migrations add Initial --project LeftOverLove.DataAccess --startup-project LeftOverLove.WebAPI/
```

### Update Database

``` shell
dotnet ef database update --project LeftOverLove.WebAPI/
```
