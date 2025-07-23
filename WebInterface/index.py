
from flask import Flask, request, rendertemplate
import requests

app = Flask(name)

@app.route('/')
def home():
    return rendertemplate('index.html')

@app.route('/command/<string:command>', methods=['POST'])
def sendcommand(command):
    cmd = request.form['cmd']  # P�e�te p��kaz odeslan� z formul��e
    response = requests.post('http://localhost:5000/command', data=cmd)
    print(response.text)
    print(f'P��kaz +{command}+ byl odesl�n')
    return 'P��kaz byl odesl�n'

if _name == '__main':
    app.run(port=8000)