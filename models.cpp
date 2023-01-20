class Vector3D 
{
public:
    Vector3D(double x, double y, double z) : x_(x), y_(y), z_(z) {}

    double x() const { return x_; }
    double y() const { return y_; }
    double z() const { return z_; }

    Vector3D operator+(const Vector3D& other) const {
        return Vector3D(x_ + other.x_, y_ + other.y_, z_ + other.z_);
    }

    Vector3D operator-(const Vector3D& other) const {
        return Vector3D(x_ - other.x_, y_ - other.y_, z_ - other.z_);
    }

    Vector3D operator*(double scalar) const {
        return Vector3D(scalar * x_, scalar * y_, scalar * z_);
    }

    double dot(const Vector3D& other) const {
        return x_ * other.x_ + y_ * other.y_ + z_ * other.z_;
    }

    Vector3D cross(const Vector3D& other) const {
        return Vector3D(
            y_ * other.z_ - z_ * other.y_,
            z_ * other.x_ - x_ * other.z_,
            x_ * other.y_ - y_ * other.x_);
    }

private:
    double x_;
    double y_;
    double z_;
};

class Ray 
{
public:
    Ray(const Vector3D& origin, const Vector3D& direction)
        : origin_(origin), direction_(direction) {}

    const Vector3D& origin() const { return origin_; }
    const Vector3D& direction() const { return direction_; }

    Vector3D pointAtDistance(double distance) const {
        return origin_ + direction_ * distance;
    }

    private:
    Vector3D origin_;
    Vector3D direction_;
};

