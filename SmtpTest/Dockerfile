FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY["SmtpTest/SmtpTest.csproj", "SmtpTest/"]
RUN dotnet restore "SmtpTest/SmtpTest.csproj"
COPY. .
WORKDIR "/src/SmtpTest"
RUN dotnet build "SmtpTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SmtpTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app.
ENTRYPOINT["dotnet", "SmtpTest.dll"]
