import requests
import json
from pymongo import MongoClient

# Retrieve data from C# API
response = requests.get('http://your-api-endpoint/api/data')
data_from_sql = response.json()
parsed_data = parse_data(data_from_sql)

# Connect to MongoDB
mongo_client = MongoClient('mongodb://localhost:27017/')
db = mongo_client['your_database']
collection = db['your_collection']


collection.insert_many(parsed_data)

print("Data inserted into MongoDB.")
