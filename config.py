username="postgres"
database="postgres"
password="1234"
host="127.0.0.1"
port = "5432"

_create_db_dictionary = {
    "name": "railway",
    "params":
        [
            {
                "name":"id",
                "type": "serial primary key"
            },
            {
                "name":"date",
                "type": "text"
            },
            {
                "name":"data",
                "type": "text"
            }
        ]
}