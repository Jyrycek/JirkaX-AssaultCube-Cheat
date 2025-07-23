
from flask import Flask, request, rendertemplate
import requests

app = Flask(name)

@app.route('/')
def home():
    return rendertemplate('index.html')

@app.route('/command/<string:command>', methods=['POST'])
def sendcommand(command):
    cmd = request.form['cmd']  # Pøeète pøíkaz odeslanı z formuláøe
    response = requests.post('http://localhost:5000/command', data=cmd)
    print(response.text)
    print(f'Pøíkaz +{command}+ byl odeslán')
    return 'Pøíkaz byl odeslán'

if _name == '__main':
    app.run(port=8000)