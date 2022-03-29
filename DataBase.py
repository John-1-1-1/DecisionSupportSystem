import psycopg2
import config

class DataBase:

    __username = None
    __database = None
    __password = None
    __host = None
    __port = None

    def __init__(self, username, database, password,
                 host, port):
        self.__username = username
        self.__database = database
        self.__password = password
        self.__host = host
        self.__port = port

    def connect_db(self):
        try:
            self.connection = psycopg2.connect(user=self.__username,
                                      database=self.__database,
                                      password=self.__password,
                                      host=self.__host,
                                      port=self.__port)
            self.cursor = self.connection.cursor()
            self.__create_db(config._create_db_dictionary)
            return "OK"
        except psycopg2.OperationalError:
            return "OperationalError"

    def __create_db(self, params):
        par = ["{0} {1},".format(i["name"], i["type"])
               for i in params["params"]]
        self.name = params["name"]
        par = "".join(par)[:-1]
        quest = """CREATE TABLE IF NOT EXISTS {0} ({1})"""\
            .format(params["name"], par)
        self.cursor.execute(quest)
        self.save()

    def insert(self, query):
        params = ",".join([i["name"] for i in query])
        value = ",".join([f"'{i['value']}'" if type(i["value"]) == str else i['value'] for i in query])
        self.cursor.execute( f"INSERT INTO {self.name} ({params}) VALUES ({value});")
        self.save()

    def select(self, params = None):
        query = f"select * from {self.name}"
        if params != None:
            query += " where "
            for i in params:
                query+=i["name"] + i["operator"]
                if type(i["value"]) == str:
                    query += "'" + i["value"] + "'"
                query += i["l_operator"]
        self.cursor.execute(query)
        mobile_records = self.cursor.fetchall()
        return mobile_records

    def save(self):
        self.connection.commit()

    def delete_all(self):
        self.cursor.execute(f"DELETE FROM {self.name};")

if __name__ == "__main__":
    db = DataBase("postgres","postgres","1234",
                           config.host, config.port)
    error = db.connect_db()
    while error != "OK":
        user = input()
        database = input()
        password = input()
        host = input()
        port = input()
        db = DataBase(username = user, database = database, password = password,
                      host = host, port = port)
        error = db.connect_db()
    db.save()
    db.insert([{"name": "data", "value": "FfddF"},
               {"name": "date", "value": "ccv" },
               {"name": "oid", "value": "1"}])
    db.save()
    print(db.select([{"name": "oid", "operator": "=", "value": "1"}]))
