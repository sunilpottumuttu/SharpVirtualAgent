#http://stackoverflow.com/questions/3276180/extracting-date-from-a-string-in-python
#Flask Specific
from IntentService import app
from flask import request
from flask import jsonify

#IntentService Related
import json
import sys
from adapt.entity_tagger import EntityTagger
from adapt.tools.text.tokenizer import EnglishTokenizer
from adapt.tools.text.trie import Trie
from adapt.intent import IntentBuilder
from adapt.parser import Parser
from adapt.engine import IntentDeterminationEngine

tokenizer = EnglishTokenizer()
trie = Trie()
tagger = EntityTagger(trie, tokenizer)
parser = Parser(tokenizer, tagger)

engine = IntentDeterminationEngine()

# define vocabulary
weather_keywords = ["weather","atmosphire"]

for wk in weather_keywords:
    engine.register_entity(wk, "WeatherKeyword")

weather_types = ["snow","rain","wind","sleet","sun"]

for wt in weather_types:
    engine.register_entity(wt, "WeatherType")

locations = ["Seattle","San Francisco","Tokyo","Delhi"]

for l in locations:
    engine.register_entity(l, "Location")

# create regex to parse out locations
#engine.register_regex_entity("in (?P<Location>.*)")

#create regex to parse date
engine.register_regex_entity("in (?P<WeatherDay>^[0-9]+$)")
#engine.register_regex_entity("in (?P<Month>.*)")


# structure intent
#QuestionLike:  what is the weather in tokyo
weather_intent = IntentBuilder("WeatherIntent")\
                .require("WeatherKeyword")\
                .optionally("WeatherType")\
                .require("Location")\
                .optionally("WeatherDay")\
                .build()
#QuestionLike:  is the weather in tokyo
#weather_yesno_intent = IntentBuilder("Weather_YesNo_Intent")\
#                .optionally("WeatherType")\
#                .require("Location")\
#                .build()

# define music vocabulary
artists = [
    "third eye blind",
    "the who",
    "the clash",
    "john mayer",
    "kings of leon",
    "adelle"
]

for a in artists:
    engine.register_entity(a, "Artist")

music_verbs = [
    "listen",
    "hear",
    "play"
]

for mv in music_verbs:
    engine.register_entity(mv, "MusicVerb")

music_keywords = [
    "songs",
    "music"
]

for mk in music_keywords:
    engine.register_entity(mk, "MusicKeyword")

music_intent = IntentBuilder("MusicIntent")\
    .require("MusicVerb")\
    .optionally("MusicKeyword")\
    .optionally("Artist")\
    .build()

engine.register_intent_parser(weather_intent);
#engine.register_intent_parser(weather_yesno_intent);
engine.register_intent_parser(music_intent);

    

@app.route('/')
@app.route('/GetIntent/<string:sentence>',methods=['GET'])
def GetIntent(sentence):
    intentResponse = { "StatusCode": "404", "Intent":{} };
    
    for intent in engine.determine_intent(sentence):
        if intent.get('confidence') > 0:
            #return json.dumps(intent, indent=4);
            intentResponse = {};
            intentResponse['StatusCode'] = "200";
            intentResponse['Intent'] = intent;
            json_data = json.dumps(intentResponse)
            return json_data;
        else:
            return jsonify(intentResponse);
    else:
        return jsonify(intentResponse);

@app.route('/TestWeatherIntent',methods=['GET'])
def TestWeatherIntent():
    for intent in engine.determine_intent("is it rainy in tokyo"):
        if intent.get('confidence') > 0:
            return json.dumps(intent, indent=4);


