import psycopg2

class DataBase:

    def __init__(self, username="postgres", database="postgres", password="1234",
                 host="127.0.0.1", port = "5432"):
        self.connection = psycopg2.connect(user=username,
                                      database=database,
                                      password=password,
                                      host=host,
                                      port=port)
        self.cursor = self.connection.cursor()

    def create_db(self, params):
        par = ["{0} {1},".format(i["name"], i["type"])
               for i in params["params"]]
        self.name = params["name"]
        par = "".join(par)[:-1]
        quest = """CREATE TABLE IF NOT EXISTS {0} ({1})"""\
            .format(params["name"], par)
        self.cursor.execute(quest)

    def insert(self, query):
        params = ",".join([i["name"] for i in query])
        value = ",".join([i["value"] for i in query])
        self.cursor.execute( f"INSERT INTO {self.name} ({params}) VALUES ('{value}');")
        self.save()

    def select(self):
        pass

    def save(self):
        self.connection.commit()


create_db = {
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


if __name__ == "__main__":
    db = DataBase()
    db.create_db(create_db)

    db.save()
