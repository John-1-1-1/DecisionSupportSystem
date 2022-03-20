from flask import Flask, redirect, url_for, request
import DataBase

db = DataBase.DataBase()
app = Flask(__name__)

@app.route('/')
def index():
    return str(db.select())

@app.route('/help')
def help():
    pass

@app.route('/add_data')
def add_data():
    db.insert()

@app.route('/login')
def login():
    username = request.args.get('username')
    print(username)
    return "OK"

if __name__ == "__main__":
    app.run()