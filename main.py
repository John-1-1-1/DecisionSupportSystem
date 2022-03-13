from flask import Flask, redirect, url_for, request

app = Flask(__name__)

@app.route('/')
def index():
    return 'Hello World'

@app.route('/get_data/<data>')
def get_data(data):
    pass

@app.route('/get_data')
def _get_data():
    return "Error. "


if __name__ == "__main__":
    app.run()