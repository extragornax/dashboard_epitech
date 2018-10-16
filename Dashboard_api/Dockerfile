FROM microsoft/dotnet

WORKDIR app

COPY . .

RUN dotnet restore

COPY . /app

RUN dotnet build

EXPOSE 8080

CMD ["dotnet", "run"]
