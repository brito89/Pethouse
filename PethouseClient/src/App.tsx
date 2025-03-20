import { Route, Routes } from "react-router-dom";
import MainPage from "./components/MainPage/MainPage";
import AdminPanel from "./components/AdminPanel/AdminPanel";

function App() {
  return (
    <Routes>
      <Route path="/" element={<MainPage />} />
      <Route path="/admin" element={<AdminPanel />} />
    </Routes>
  );
}

export default App;
