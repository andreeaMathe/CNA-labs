import com.google.protobuf.Empty;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import proto.BookClient.BookOuterClass;
import proto.BookClient.BookstoreGrpc;

public class Main {
    public static void main(String[] args) {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 5001).usePlaintext().build();
        BookstoreGrpc.BookstoreBlockingStub bookStub = BookstoreGrpc.newBlockingStub(channel);

        BookOuterClass.GetAllBooksResponse response = bookStub.getAllBooks(Empty.newBuilder().build());
        System.out.println(response.getBooksList());

        channel.shutdown();
    }
}
