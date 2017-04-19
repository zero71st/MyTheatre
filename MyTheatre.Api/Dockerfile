FROM microsoft/aspnetcore-build
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -o ./out -c Release
ENTRYPOINT dotnet ./out/MyTheatre.Api.dll

