import { Link } from "react-router-dom";

const MainPage = () => {
  return (
    <div className="main-page bg-dark">
      <h1>Welcome to the Main Page!</h1>
      <Link to="/admin">Go to Admin Panel</Link>
    </div>
  );
};

export default MainPage;
