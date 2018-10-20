FROM microsoft/dotnet

WORKDIR app

COPY . .

RUN dotnet restore

EXPOSE 8080

CMD ["dotnet", "run"]
