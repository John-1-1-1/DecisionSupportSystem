from flask import Flask, redirect, url_for, request
import DataBase

db = DataBase.DataBase()
db.connect_db()
app = Flask(__name__)

@app.route('/get_data', methods = ['POST'])
def index():
    oid = request.args.get('oid')
    return str(db.select([{"name": "oid", "operator": "=", "value": oid}]))



@app.route('/add_data',methods = ['POST'])
def add_data():
    oid = request.args.get('oid')
    params = request.args.get('params')
    db.insert([
        {"name": 'oid', "value": str(oid)},
        {"name": 'data', "value": str(params)}
    ])
    return "OK"

