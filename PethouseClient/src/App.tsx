import { useEffect, useState } from "react";

function App() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Fetch the API
    fetch("http://localhost:8080/api/Appointments") // Use service name as hostname
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        setData(data); // Set the fetched data
        setLoading(false); // Turn off loading
      })
      .catch((error) => {
        console.error("There was an error fetching the data:", error);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <div style={{ margin: "50px" }}>Loading...</div>;
  }

  return (
    <div>
      <h1 style={{ margin: "50px" }}>Awesome Data from .NET API:</h1>
      <pre style={{ margin: "50px" }}>{JSON.stringify(data, null, 2)}</pre>
    </div>
  );
}

export default App;
