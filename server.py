from flask import Flask, redirect, url_for, request
import DataBase
import config
import snmp

db = None
app = Flask(__name__)

@app.route('/get_data', methods = ['POST'])
def index():
    oid = request.args.get('oid')
    global db
    if db != None:
        return str(db.select([{"name": "oid", "operator": "=", "value": oid}]))
    else:
        return "don't log in"

@app.route('/all')
def all():
    global db
    if db != None:
        return str(db.select())
    else:
        return "don't log in"

@app.route('/login')
def login():
    global db
    username = request.args.get('username')
    database = request.args.get('database')
    password = request.args.get('password')
    db = DataBase.DataBase(username,database,password,
                           config.host, config.port)
    db.connect_db()
    return "OK"

@app.route("/logout")
def logout():
    global db
    db = None
    return "OK"

@app.route('/help')
def help():
    pass

@app.route('/deleteAll')
def delete():
    global db
    if db != None:
        return str(db.delete_all())
    else:
        return "don't log in"

@app.route('/beta_get')
def add_data():
    id = request.args.get('id')
    oids = request.args.get('oids').split("|")
    return "|".join([str(i) for i in snmp.get_value(oids)])


@app.route('/add_data')
def add_dataq():
    global db
    oid = request.args.get('oid')
    params = request.args.get('params')
    if db != None:
        db.insert([
            {"name": 'oid', "value": str(oid)},
            {"name": "date", "value": "ccv"},
            {"name": 'data', "value": str(params)}
        ])
        return "OK"
    else:
        return "don't log in"

