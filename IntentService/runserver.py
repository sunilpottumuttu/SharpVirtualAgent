"""
This script runs the IntentService application using a development server.
"""

from os import environ
from IntentService import app

if __name__ == '__main__':
    HOST = environ.get('SERVER_HOST', 'localhost')
    try:
        PORT = int(environ.get('SERVER_PORT', '55555'))
    except ValueError:
        PORT = 55555
    #app.run(HOST, PORT)
    app.run(host="127.0.0.1",port="5555");
