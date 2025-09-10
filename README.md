# Province API

Dự án API cung cấp thông tin về các đơn vị hành chính của Việt Nam.

## Kiến trúc và Thiết kế

Dự án này được xây dựng dựa trên nguyên tắc của **Clean Architecture**, giúp tách biệt các mối quan tâm (separation of concerns), làm cho mã nguồn dễ đọc, dễ bảo trì và mở rộng.

Cấu trúc các lớp (layers) chính:

-   **Core**: Chứa logic nghiệp vụ cốt lõi của ứng dụng.
    -   `Domain`: Bao gồm các entities (ví dụ: `AdministrativeUnit`) và các quy tắc nghiệp vụ cốt lõi nhất.
    -   `Application`: Chứa các interfaces (contracts) cho repositories, services, unit of work và các DTOs (Data Transfer Objects).
-   **Infrastructure**: Chứa các triển khai cụ thể cho các thành phần bên ngoài. Đây là nơi triển khai các interface từ lớp `Application`, ví dụ như truy cập cơ sở dữ liệu (sử dụng Entity Framework Core), logging, hay gọi các dịch vụ bên thứ ba.
-   **Presentation (Province_API)**: Là lớp giao tiếp với người dùng hoặc các hệ thống khác. Trong dự án này, đó là các API endpoints được xây dựng bằng ASP.NET Core, tiếp nhận request và trả về response.
-   **Usecase**: Chứa các kịch bản sử dụng cụ thể của ứng dụng, điều phối luồng dữ liệu và thực thi logic nghiệp vụ bằng cách sử dụng các thành phần từ `Core` và `Infrastructure`.

### Các Design Pattern nổi bật

Dự án áp dụng nhiều design pattern phổ biến để giải quyết các vấn đề thiết kế một cách hiệu quả:

-   **Repository Pattern & Unit of Work Pattern**: Trừu tượng hóa lớp truy cập dữ liệu. Repository giúp che giấu logic truy vấn dữ liệu cho từng aggregate, trong khi Unit of Work quản lý các giao dịch (transactions) để đảm bảo tính toàn vẹn dữ liệu.
-   **Dependency Injection (DI)**: Được sử dụng xuyên suốt dự án (thông qua DI container có sẵn của ASP.NET Core) để giảm sự phụ thuộc giữa các thành phần (decoupling) và tăng tính linh hoạt, dễ dàng cho việc viết unit test.
-   **Builder Pattern**: Được sử dụng để xây dựng các đối tượng phức tạp từng bước, ví dụ như `AdministrativeUnitBuilder` giúp tạo ra một đơn vị hành chính với các thuộc tính phức tạp.
-   **Data Transfer Object (DTO)**: Dùng để truyền dữ liệu giữa các lớp, đặc biệt là giữa `Application` và `Presentation`, giúp che giấu cấu trúc của domain models và chỉ gửi những dữ liệu cần thiết.