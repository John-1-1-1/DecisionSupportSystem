from flask import Flask, redirect, url_for, request
import DataBase

db = DataBase.DataBase()
db.connect_db()
app = Flask(__name__)

@app.route('/')
def index():
    return str(db.select())

@app.route('/help')
def help():
    pass

@app.route('/add_data',methods = ['POST'])
def add_data():
    oid = request.args.get('oid')
    params = request.args.get('params')
    db.insert([
        {"name": 'oid', "value": str(oid)},
        {"name": 'params', "value": str(params)}
    ])
    return "OK"

if __name__ == "__main__":
    app.run()