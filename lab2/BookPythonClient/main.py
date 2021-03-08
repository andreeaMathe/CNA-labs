# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.
import os

import grpc
from google.protobuf import empty_pb2

import book_pb2
import book_pb2_grpc


def call_grpc_server():
    channel = grpc.insecure_channel('localhost:5001', options=(('grpc.enable_http_proxy', 0),))
    stub = book_pb2_grpc.BookstoreStub(channel)
    book = book_pb2.Book(title="Alice in Wonderland")
    response = stub.AddBook(book_pb2.AddBookRequest(book=book))
    print(response)
    channel.close()


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    call_grpc_server()


# See PyCharm help at https://www.jetbrains.com/help/pycharm/
