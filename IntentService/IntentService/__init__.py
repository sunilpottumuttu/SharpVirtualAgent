"""
The flask application package.
"""

from flask import Flask
app = Flask(__name__)

import IntentService.controllers
import IntentService.IntentController
import flask
import json
