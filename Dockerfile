FROM mcr.microsoft.com/dotnet/aspnet:6.0.21-jammy-amd64
WORKDIR /solicitudes
COPY ./solicitudes ./
RUN chmod +x ./Solicitudes.dll
# CMD ["dotnet", "Solicitudes.dll"]
# CMD ["./Solicitudes.dll"]
