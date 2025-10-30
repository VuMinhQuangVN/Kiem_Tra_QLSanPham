\# Hệ thống Quản lý Sản phẩm - ASP.NET Core MVC



Đây là project bài kiểm tra giữa kỳ môn Lập trình .NET Doanh nghiệp, được thực hiện bởi \*\*Vũ Minh Quang\*\*. Ứng dụng web được xây dựng theo mô hình \*\*ASP.NET Core MVC\*\* để quản lý danh sách sản phẩm với các chức năng CRUD cơ bản và nâng cao.



Dự án tập trung vào việc áp dụng các nguyên lý \*\*SOLID\*\* và kiến trúc \*\*Clean Code\*\*, tách biệt rõ ràng các tầng \*\*Controller - Service - Repository\*\* để đảm bảo code dễ bảo trì, dễ mở rộng và dễ kiểm thử.



\## 🚀 Công nghệ sử dụng



\*   \*\*Backend:\*\* ASP.NET Core MVC (.NET 8.0)

\*   \*\*Database:\*\* SQL Server, Entity Framework Core (Code-First Migration)

\*   \*\*Frontend:\*\* HTML, CSS, Bootstrap 5 (từ CDN), JavaScript (jQuery \& Unobtrusive Validation cho validation phía client)

\*   \*\*Kiến trúc:\*\* SOLID, Clean Code, Repository Pattern, Service Layer, Dependency Injection



\## ✨ Tính năng chính



\*   \*\*Quản lý sản phẩm (CRUD):\*\*

&nbsp;   \*   Xem danh sách tất cả sản phẩm.

&nbsp;   \*   Thêm một sản phẩm mới.

&nbsp;   \*   Cập nhật thông tin sản phẩm.

&nbsp;   \*   Xem thông tin chi tiết của một sản phẩm.

&nbsp;   \*   Xóa một sản phẩm khỏi hệ thống.

\*   \*\*Tìm kiếm:\*\* Lọc sản phẩm theo tên một cách nhanh chóng.

\*   \*\*Phân trang:\*\* Chia danh sách sản phẩm thành nhiều trang để dễ dàng điều hướng khi có số lượng lớn dữ liệu.

\*   \*\*Validation:\*\* Kiểm tra tính hợp lệ của dữ liệu đầu vào cả phía Client (JavaScript) và phía Server (DataAnnotations) để đảm bảo tính toàn vẹn dữ liệu.



\## 🛠️ Cài đặt và Chạy dự án



Để chạy dự án này trên máy của bạn, hãy làm theo các bước sau:



\### Yêu cầu

\*   \[.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) hoặc mới hơn.

\*   \[SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (phiên bản Express là đủ).

\*   Một trình soạn thảo code như \[Visual Studio 2022](https://visualstudio.microsoft.com/) hoặc \[Visual Studio Code](https://code.visualstudio.com/).



\### Các bước cài đặt



1\.  \*\*Clone repository về máy của bạn:\*\*

&nbsp;   ```bash

&nbsp;   git clone https://github.com/VuMinhQuangVN/Kiem\_Tra\_30\_10\_2025.git

&nbsp;   ```



2\.  \*\*Cấu hình chuỗi kết nối (Connection String):\*\*

&nbsp;   \*   Mở file `appsettings.json`.

&nbsp;   \*   Tìm đến mục `ConnectionStrings` và thay đổi giá trị của `DefaultConnection` để trỏ đến instance SQL Server trên máy của bạn.

&nbsp;   \*   Ví dụ: đổi `Server=localhost\\\\SQLEXPRESS01` thành `Server=TEN\_SERVER\_CUA\_BAN`.



3\.  \*\*Áp dụng Migration để tạo cơ sở dữ liệu:\*\*

&nbsp;   \*   Mở một cửa sổ terminal tại thư mục gốc của dự án.

&nbsp;   \*   Chạy lệnh sau:

&nbsp;   ```bash

&nbsp;   dotnet ef database update

&nbsp;   ```

&nbsp;   Lệnh này sẽ tự động tạo database `QuanLySanPhamKT` và bảng `Products` dựa trên code.



4\.  \*\*Chạy ứng dụng:\*\*

&nbsp;   \*   Vẫn ở trong terminal, chạy lệnh:

&nbsp;   ```bash

&nbsp;   dotnet run

&nbsp;   ```



5\.  \*\*Truy cập ứng dụng:\*\*

&nbsp;   \*   Mở trình duyệt và truy cập vào địa chỉ được hiển thị trong terminal (thường là `https://localhost:7xxx` hoặc `http://localhost:5xxx`).



\## 🏗️ Kiến trúc Dự án



Dự án tuân thủ chặt chẽ kiến trúc phân tầng để đảm bảo các nguyên tắc SOLID.



\*   \*\*`Controllers`\*\*: Chịu trách nhiệm nhận HTTP request từ người dùng, gọi đến Service tương ứng và trả về View.

\*   \*\*`Services`\*\*: Chứa logic nghiệp vụ chính (business logic), điều phối các hoạt động và mapping dữ liệu giữa DTO và Model.

\*   \*\*`Repositories`\*\*: Là tầng duy nhất chịu trách nhiệm giao tiếp trực tiếp với cơ sở dữ liệu (thông qua `DbContext`).

\*   \*\*`Models`\*\*: Định nghĩa các thực thể (entities) được ánh xạ xuống bảng trong database.

\*   \*\*`DTOs`\*\*: (Data Transfer Objects) Các đối tượng dùng để truyền dữ liệu giữa các tầng và ra ngoài View, giúp che giấu cấu trúc Model thực tế.

\*   \*\*`Views`\*\*: Chịu trách nhiệm hiển thị giao diện người dùng.



\### Luồng dữ liệu```

Request (View) -> Controller -> Service -> Repository -> Database

```

