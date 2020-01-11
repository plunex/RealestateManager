# RealEstateManagement with GraphQl

### Run the container: (Note install 2017 sql server) (we use single quote because of the special character inbetween)
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MyComplexPassword!234' -p 1433:1433 -v /user/my/db:/var/opt/mssql -d microsoft/mssql-server-linux

