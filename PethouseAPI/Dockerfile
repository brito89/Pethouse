# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

#RUN dotnet tool install --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"

# Copy the project files and restore dependencies
COPY PethouseAPI/*.csproj ./
RUN dotnet restore

# Copy the rest of the application files and build it
COPY . ./
RUN dotnet publish "PethouseAPI" -c Release -o out

# Use the ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "PethouseAPI.dll"]
