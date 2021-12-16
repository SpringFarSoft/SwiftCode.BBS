FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY . .
ENTRYPOINT ["dotnet", "SwiftCode.BBS.API.dll"]