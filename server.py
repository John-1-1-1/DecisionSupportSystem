from flask import Flask, redirect, url_for, request
import DataBase
import config

db = None
app = Flask(__name__)

@app.route('/get_data', methods = ['POST'])
def index():
    oid = request.args.get('oid')
    global db
    return str(db.select([{"name": "oid", "operator": "=", "value": oid}]))

@app.route('/all')
def all():
    global db
    return str(db.select())


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
    db.delete_all()


@app.route('/add_data',methods = ['POST'])
def add_data():
    global db
    oid = request.args.get('oid')
    params = request.args.get('params')
    db.insert([
        {"name": 'oid', "value": str(oid)},
        {"name": "date", "value": "ccv"},
        {"name": 'data', "value": str(params)}
    ])
    return "OK"

