# Panda API

### Getting started

```bash
# Restore nuget dependencies
dotnet restore
```

```bash
# Copy app settings for development (Remember to add details after copy)
cp appsettings.Development.example.json appsettings.Development.json
```

```bash
# Copy app settings for production (Remember to add details after copy)
cp appsettings.example.json appsettings.json
```

```bash
# Test builds work fine
dotnet build
```

```bash
# Serve locally
dotnet run
```