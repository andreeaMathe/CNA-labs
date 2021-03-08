package proto.BookClient;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.15.0)",
    comments = "Source: book.proto")
public final class BookstoreGrpc {

  private BookstoreGrpc() {}

  public static final String SERVICE_NAME = "bookstore.Bookstore";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<proto.BookClient.BookOuterClass.AddBookRequest,
      proto.BookClient.BookOuterClass.AddBookResponse> getAddBookMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "AddBook",
      requestType = proto.BookClient.BookOuterClass.AddBookRequest.class,
      responseType = proto.BookClient.BookOuterClass.AddBookResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<proto.BookClient.BookOuterClass.AddBookRequest,
      proto.BookClient.BookOuterClass.AddBookResponse> getAddBookMethod() {
    io.grpc.MethodDescriptor<proto.BookClient.BookOuterClass.AddBookRequest, proto.BookClient.BookOuterClass.AddBookResponse> getAddBookMethod;
    if ((getAddBookMethod = BookstoreGrpc.getAddBookMethod) == null) {
      synchronized (BookstoreGrpc.class) {
        if ((getAddBookMethod = BookstoreGrpc.getAddBookMethod) == null) {
          BookstoreGrpc.getAddBookMethod = getAddBookMethod = 
              io.grpc.MethodDescriptor.<proto.BookClient.BookOuterClass.AddBookRequest, proto.BookClient.BookOuterClass.AddBookResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "bookstore.Bookstore", "AddBook"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  proto.BookClient.BookOuterClass.AddBookRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  proto.BookClient.BookOuterClass.AddBookResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new BookstoreMethodDescriptorSupplier("AddBook"))
                  .build();
          }
        }
     }
     return getAddBookMethod;
  }

  private static volatile io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      proto.BookClient.BookOuterClass.GetAllBooksResponse> getGetAllBooksMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetAllBooks",
      requestType = com.google.protobuf.Empty.class,
      responseType = proto.BookClient.BookOuterClass.GetAllBooksResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      proto.BookClient.BookOuterClass.GetAllBooksResponse> getGetAllBooksMethod() {
    io.grpc.MethodDescriptor<com.google.protobuf.Empty, proto.BookClient.BookOuterClass.GetAllBooksResponse> getGetAllBooksMethod;
    if ((getGetAllBooksMethod = BookstoreGrpc.getGetAllBooksMethod) == null) {
      synchronized (BookstoreGrpc.class) {
        if ((getGetAllBooksMethod = BookstoreGrpc.getGetAllBooksMethod) == null) {
          BookstoreGrpc.getGetAllBooksMethod = getGetAllBooksMethod = 
              io.grpc.MethodDescriptor.<com.google.protobuf.Empty, proto.BookClient.BookOuterClass.GetAllBooksResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "bookstore.Bookstore", "GetAllBooks"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.google.protobuf.Empty.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  proto.BookClient.BookOuterClass.GetAllBooksResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new BookstoreMethodDescriptorSupplier("GetAllBooks"))
                  .build();
          }
        }
     }
     return getGetAllBooksMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static BookstoreStub newStub(io.grpc.Channel channel) {
    return new BookstoreStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static BookstoreBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new BookstoreBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static BookstoreFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new BookstoreFutureStub(channel);
  }

  /**
   */
  public static abstract class BookstoreImplBase implements io.grpc.BindableService {

    /**
     */
    public void addBook(proto.BookClient.BookOuterClass.AddBookRequest request,
        io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.AddBookResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getAddBookMethod(), responseObserver);
    }

    /**
     */
    public void getAllBooks(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.GetAllBooksResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getGetAllBooksMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getAddBookMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                proto.BookClient.BookOuterClass.AddBookRequest,
                proto.BookClient.BookOuterClass.AddBookResponse>(
                  this, METHODID_ADD_BOOK)))
          .addMethod(
            getGetAllBooksMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Empty,
                proto.BookClient.BookOuterClass.GetAllBooksResponse>(
                  this, METHODID_GET_ALL_BOOKS)))
          .build();
    }
  }

  /**
   */
  public static final class BookstoreStub extends io.grpc.stub.AbstractStub<BookstoreStub> {
    private BookstoreStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookstoreStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookstoreStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookstoreStub(channel, callOptions);
    }

    /**
     */
    public void addBook(proto.BookClient.BookOuterClass.AddBookRequest request,
        io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.AddBookResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getAddBookMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getAllBooks(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.GetAllBooksResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGetAllBooksMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class BookstoreBlockingStub extends io.grpc.stub.AbstractStub<BookstoreBlockingStub> {
    private BookstoreBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookstoreBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookstoreBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookstoreBlockingStub(channel, callOptions);
    }

    /**
     */
    public proto.BookClient.BookOuterClass.AddBookResponse addBook(proto.BookClient.BookOuterClass.AddBookRequest request) {
      return blockingUnaryCall(
          getChannel(), getAddBookMethod(), getCallOptions(), request);
    }

    /**
     */
    public proto.BookClient.BookOuterClass.GetAllBooksResponse getAllBooks(com.google.protobuf.Empty request) {
      return blockingUnaryCall(
          getChannel(), getGetAllBooksMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class BookstoreFutureStub extends io.grpc.stub.AbstractStub<BookstoreFutureStub> {
    private BookstoreFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookstoreFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookstoreFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookstoreFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<proto.BookClient.BookOuterClass.AddBookResponse> addBook(
        proto.BookClient.BookOuterClass.AddBookRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getAddBookMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<proto.BookClient.BookOuterClass.GetAllBooksResponse> getAllBooks(
        com.google.protobuf.Empty request) {
      return futureUnaryCall(
          getChannel().newCall(getGetAllBooksMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_ADD_BOOK = 0;
  private static final int METHODID_GET_ALL_BOOKS = 1;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final BookstoreImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(BookstoreImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_ADD_BOOK:
          serviceImpl.addBook((proto.BookClient.BookOuterClass.AddBookRequest) request,
              (io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.AddBookResponse>) responseObserver);
          break;
        case METHODID_GET_ALL_BOOKS:
          serviceImpl.getAllBooks((com.google.protobuf.Empty) request,
              (io.grpc.stub.StreamObserver<proto.BookClient.BookOuterClass.GetAllBooksResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class BookstoreBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    BookstoreBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return proto.BookClient.BookOuterClass.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("Bookstore");
    }
  }

  private static final class BookstoreFileDescriptorSupplier
      extends BookstoreBaseDescriptorSupplier {
    BookstoreFileDescriptorSupplier() {}
  }

  private static final class BookstoreMethodDescriptorSupplier
      extends BookstoreBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    BookstoreMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (BookstoreGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new BookstoreFileDescriptorSupplier())
              .addMethod(getAddBookMethod())
              .addMethod(getGetAllBooksMethod())
              .build();
        }
      }
    }
    return result;
  }
}
